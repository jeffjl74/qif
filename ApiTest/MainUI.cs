using System;
using System.Windows.Forms;
using System.IO;
using QifDoc.Qif;
using System.Collections.Generic;
using System.Reflection;

namespace QifInspector
{
    /// <summary>
    /// QIF file Inspector
    /// </summary>
    /// <remarks>
    /// This program reads a file into a QifDocument and displays the parsed data.
    /// The program is not really intended to show the usage of QiFDocument so much,
    /// but to show the result of parsing a file. It simply does a ToString()
    /// on everything it parsed. Except in the case of the !Option:AutoSwitch
    /// accounts, it doesn't even figure out what it parsed, it just displays
    /// its ToString().
    /// 
    /// It starts by trying to load the 'sample.qif' file located in its folder.
    /// </remarks>
    public partial class MainUI : Form
    {
        QifDocument qif;
        public MainUI()
        {
            InitializeComponent();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    qif = QifDocument.Load(sr);
                    this.Text = "QIF Inspector - " + Path.GetFileName(fileName);
                }
                PopulateTree();
            }
        }


        private void MainUI_Load(object sender, EventArgs e)
        {
            var fileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\sample.qif";
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    qif = QifDocument.Load(sr);
                    this.Text = "QIF Inspector - " + Path.GetFileName(fileName);
                }
                PopulateTree();
            }
        }

        private void PopulateTree()
        {
            treeView1.Nodes.Clear();

            if (qif != null)
            {
                Type t = qif.GetType();
                PropertyInfo[] props = t.GetProperties();
                Array.Sort(props, delegate (PropertyInfo x, PropertyInfo y) { return x.Name.CompareTo(y.Name); });
                foreach (var prop in props)
                {
                    if (prop.GetIndexParameters().Length == 0)
                    {
                        object obj = prop.GetValue(qif);
                        int count = 0;
                        string text = prop.Name;
                        //Want to add a transaction count to the tree text.
                        //Just cast it as a generic list since we don't know the type.
                        IEnumerable<object> list = obj as IEnumerable<object>;
                        if (list != null)
                        {
                            //can't get the count from IEnumerable<object>
                            //so do it by hand
                            foreach (object item in list)
                                count++;
                            if(count > 0)
                                text += $" ({count})";
                        }
                        else
                        {
                            AutoSwitchAccountList asl = obj as AutoSwitchAccountList;
                            if(asl.autoSwitchAccounts.Count > 0)
                                text += $" ({asl.autoSwitchAccounts.Count})";
                        }
                        TreeNode node = new TreeNode(text);
                        node.Name = prop.Name;
                        treeView1.Nodes.Add(node);

                        if (list == null)
                        {
                            // the only property that is not a list is the auto switch class
                            // add its accounts as nodes in the tree
                            AutoSwitchAccountList asl = obj as AutoSwitchAccountList;
                            if (asl != null)
                            {
                                foreach (AutoSwitchAccount acct in asl.autoSwitchAccounts)
                                {
                                    TreeNode acctNode = new TreeNode(acct.accountListTransaction.Name);
                                    acctNode.Name = acct.accountListTransaction.Name;
                                    node.Nodes.Add(acctNode);

                                    //add it's transaction lists as sub nodes
                                    Type autot = acct.GetType();
                                    PropertyInfo[] autoProps = autot.GetProperties();
                                    Array.Sort(autoProps, delegate (PropertyInfo x, PropertyInfo y) { return x.Name.CompareTo(y.Name); });

                                    foreach (var sub in autoProps)
                                    {
                                        object o = sub.GetValue(acct);
                                        int autoCount = 0;
                                        string autoText = sub.Name;
                                        //Want to add a transaction count to the tree text.
                                        //Just cast it as a generic list since we don't know the type.
                                        IEnumerable<object> alist = o as IEnumerable<object>;
                                        if (alist != null)
                                        {
                                            //can't get the count from IEnumerable<object>
                                            //so do it by hand
                                            foreach (object item in alist)
                                                autoCount++;
                                            if (autoCount > 0)
                                                autoText += $" ({autoCount})";
                                        }

                                        TreeNode autoNode = new TreeNode(autoText);
                                        autoNode.Name = sub.Name;
                                        acctNode.Nodes.Add(autoNode);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listBox1.Items.Clear();

            if (e.Node.Level < 2)
            {
                Type type = qif.GetType();
                PropertyInfo[] props = type.GetProperties();
                foreach (var prop in props)
                {
                    if (prop.Name == e.Node.Name)
                    {
                        object obj = prop.GetValue(qif);
                        //Type[] myListElementType = obj.GetType().GetGenericArguments();
                        IEnumerable<object> list = obj as IEnumerable<object>;
                        if (list == null)
                        {
                            AutoSwitchAccountList asl = obj as AutoSwitchAccountList;
                            if (asl != null)
                            {
                                list = asl.autoSwitchAccounts as IEnumerable<object>;
                            }
                        }
                        if (list != null)
                        {
                            foreach (object item in list)
                                listBox1.Items.Add(item.ToString());
                        }
                        break;
                    }
                }
            }
            else if(e.Node.Level == 2)
            {
                //autoswitch account

                //find the selected accountAutoSwitchAccount
                AutoSwitchAccount parent = null;
                foreach (AutoSwitchAccount acct in qif.AutoSwitchAccountList.autoSwitchAccounts)
                {
                    if (acct.accountListTransaction.Name.Equals(e.Node.Parent.Name))
                        parent = acct;
                }
                if (parent != null)
                {
                    Type type = parent.GetType();
                    PropertyInfo[] props = type.GetProperties();
                    foreach (var prop in props)
                    {
                        if (prop.Name == e.Node.Name)
                        {
                            object obj = prop.GetValue(parent);
                            IEnumerable<object> list = obj as IEnumerable<object>;
                            if (list != null)
                            {
                                foreach (object item in list)
                                    listBox1.Items.Add(item.ToString());
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
