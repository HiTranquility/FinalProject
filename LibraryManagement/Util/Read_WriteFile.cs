namespace LibraryManagement.Util
{
    internal class Read_WriteFile
    {
        // Singleton instance
        private static Read_WriteFile _instance;

        // Private constructor to prevent instantiation
        private Read_WriteFile() { }

        // Public property to access the single instance
        public static Read_WriteFile Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Read_WriteFile();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Reads content from a file.
        /// </summary>
        /// <param name="filePath">Path to the file to be read.</param>
        /// <returns>Content of the file as a string.</returns>
        public string ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file does not exist.");
            }

            return File.ReadAllText(filePath);
        }

        /// <summary>
        /// Writes content to a file.
        /// </summary>
        /// <param name="filePath">Path to the file where content will be written.</param>
        /// <param name="content">Content to write to the file.</param>
        public void WriteFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }

        // Appends content to a file
        public void AppendToFile(string filePath, string content)
        {
            File.AppendAllText(filePath, content);
        }
    }
}
