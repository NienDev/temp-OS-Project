using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using WpfApp1.Testing;
using WpfApp1.Testing.ViewModels;
using WpfApp1.Testing.Multiple_Views.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
                
        }
        #endregion


        #region On loaded
        /// <summary>
        /// When application first open
        /// </summary>

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // get all the drive names (ex: D:\)
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem();
                item.Header = drive;
                item.Tag = drive;
                if (isFileFolderInDriveDir(drive))
                {
                    item.Items.Add(null);
                    item.Expanded += Folder_Expanded;
                }
                FolderView.Items.Add(item);
            }
        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;
            // if the list contain only dummy data
            if (item.Items.Count != 1 || item.Items[0] != null) return;

            // clear dummy data
            item.Items.Clear();

            #region Get Folders
            // get full path
            var fullPath = (string)item.Tag;

            var directories = new List<string>();

            // use try catch here to avoid the error which is can not access to the system column folder
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }
            }
            catch
            {

            }
           
            directories.ForEach(directoryPath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(directoryPath),
                    Tag = directoryPath
                };

                if (isFileFolderInDriveDir(directoryPath))
                {
                    subItem.Items.Add(null);

                    subItem.Expanded += Folder_Expanded;
                }
                

                item.Items.Add(subItem);
            });
            #endregion

            #region Get Files

            var files = new List<string>();

            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0) files.AddRange(fs); 
            }
            catch { }
            files.ForEach(filePath =>
            {
                // create item for a file
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(filePath),
                    Tag = filePath
                };
                item.Items.Add(subItem);

            });

            #endregion
        }

        #endregion

        #region Find folder/file name
        /// <summary>
        /// Find a folder/file name from full path
        /// </summary>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // if we have empty/null string
            if (string.IsNullOrEmpty(path)) return string.Empty;

            var normalizedPath = path.Replace('/', '\\');

            var lastIndex = normalizedPath.LastIndexOf('\\');

            // if we don't find the backslash index then full path itself is the name
            if (lastIndex <= 0) return path;

            // return the string after the last backslash(the name we want to find)
            return path.Substring(lastIndex + 1);
        }
        #endregion

        #region If Drive/Folder contain any folder/file
        /// <summary>
        /// Check if drive/folder contain any folder or file 
        /// </summary>
        
        public static bool isFileFolderInDriveDir(string path)
        {
            var directories = new List<string>();
            var files = new List<string>();

            try
            {
                var dirs = Directory.GetDirectories(path);
                if (dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }
            }
            catch
            {

            }

            try
            {
                var fs = Directory.GetFiles(path);
                if (fs.Length > 0) files.AddRange(fs);
            }
            catch { }

            if (directories.Count > 0 || files.Count > 0)
            {
                return true;
            }
            
            return false;
        }
        #endregion

        private void Show_Kim_Msg_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new KimMessageViewModel();
        }

        private void Show_Nien_Msg_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new NienMessageViewModel();
        }
    }
}
