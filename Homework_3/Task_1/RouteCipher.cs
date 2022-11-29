using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class RouteCipher
    {
        #region Data members
        
        private int key;

        #endregion

        #region Constructors
        
        /// <summary>
        /// General-purpose constructor
        /// </summary>
        /// <param name="key"></param>
        public RouteCipher(int key)
        {
            Key = key;
        }

        #endregion

        #region Properties

        public int Key
        {
            get { return key; }
            set { key = value; }
        }

        #endregion

        #region Methods

        #region Private utility methods
        
        /// <summary>
        /// Creates matrix from char array based on row amount and Key property
        /// </summary>
        /// <param name="plainTextChar">Initial char array</param>
        /// <param name="rowCount"></param>
        /// <returns>Matrix that contains initial char array</returns>
        private char[,] CreateMatrixFromCharArray(char[] plainTextChar, int rowCount)
        {
            char[,] matrix = new char[rowCount, Math.Abs(Key)];

            int row = 0;
            int column = 0;
            for (int i = 0; ; i++)
            {
                if (column == Math.Abs(Key) && row != rowCount - 1)
                {
                    row++;
                    column = 0;
                }

                if (row == rowCount - 1 && column == Math.Abs(Key)) break;

                if (i >= plainTextChar.Length)
                {
                    matrix[row, column++] = 'X';
                    continue;
                }

                matrix[row, column++] = plainTextChar[i];
            }

            return matrix;
        }
        /// <summary>
        /// Encrypts text beginning at top left corner
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns>Encrypted text</returns>
        private string EncryptWithPositiveKey(string plainText)
        {
            char[] plainTextChar = plainText.ToCharArray();

            int columnCount = Math.Abs(Key);
            int rowCount = plainTextChar.Length % columnCount != 0 ? plainTextChar.Length / columnCount + 1 : plainTextChar.Length / columnCount;

            char[,] matrix = CreateMatrixFromCharArray(plainTextChar, rowCount);

            int rowStart = 0, columnStart = 0;
            int total = rowCount * columnCount;
            int count = 0;

            int i;
            char[] result = new char[total];

            while (rowStart < rowCount && columnStart < columnCount)
            {
                if (count == total) break;

                for (i = rowStart; i < rowCount; i++)
                {
                    result[count++] = matrix[i, columnStart];
                }
                columnStart++;

                if (count == total) break;

                for (i = columnStart; i < columnCount; i++)
                {
                    result[count++] = matrix[rowCount - 1, i];
                }
                rowCount--;

                if (count == total) break;

                if (rowStart < rowCount)
                {
                    for (i = rowCount - 1; i >= rowStart; i--)
                    {
                        result[count++] = matrix[i, columnCount - 1];
                    }
                    columnCount--;
                }

                if (count == total) break;

                if (columnStart < columnCount)
                {
                    for (i = columnCount - 1; i >= columnStart; i--)
                    {
                        result[count++] = matrix[rowStart, i];
                    }
                    rowStart++;
                }
            }

            return new string(result);
        }
        /// <summary>
        /// Encrypts text beginning at bottom right corner
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns>Encrypted text</returns>
        private string EncryptWithNegativeKey(string plainText)
        {
            char[] plainTextChar = plainText.ToCharArray();

            int columnCount = Math.Abs(Key);
            int rowCount = plainTextChar.Length % columnCount != 0 ? plainTextChar.Length / columnCount + 1 : plainTextChar.Length / columnCount;

            char[,] matrix = CreateMatrixFromCharArray(plainTextChar, rowCount);

            int rowStart = rowCount - 1, columnStart = columnCount - 1;
            int rowEnd = 0, columnEnd = 0;
            int total = rowCount * columnCount;
            int count = 0;

            int i;
            char[] result = new char[total];

            while (rowStart >= rowEnd && columnStart >= columnEnd)
            {
                if (count == total) break;

                for (i = rowStart; i >= rowEnd; i--)
                {
                    result[count++] = matrix[i, columnStart];
                }
                columnStart--;

                if (count == total) break;

                for (i = columnStart; i >= columnEnd; i--)
                {
                    result[count++] = matrix[rowEnd, i];
                }
                rowEnd++;

                if (count == total) break;

                if (rowStart >= rowEnd)
                {
                    for (i = rowEnd; i <= rowStart; i++)
                    {
                        result[count++] = matrix[i, columnEnd];
                    }
                    columnEnd++;
                }

                if (count == total) break;

                if (columnStart >= columnEnd)
                {
                    for (i = columnEnd; i <= columnStart; i++)
                    {
                        result[count++] = matrix[rowStart, i];
                    }
                    rowStart--;
                }
            }
            return new string(result);
        }
        /// <summary>
        /// Decrypts text encrypted with EncryptWithPositiveKey method
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns>Decrypted text/returns>
        private string DecryptWithPositiveKey(string cipherText)
        {
            char[] cipherTextChar = cipherText.ToCharArray();

            int columnCount = Math.Abs(Key);
            int rowCount = cipherTextChar.Length % columnCount != 0 ? cipherTextChar.Length / columnCount + 1 : cipherTextChar.Length / columnCount;

            char[,] matrix = new char[rowCount, columnCount];

            int rowStart = 0, columnStart = 0;
            int total = rowCount * columnCount;
            int count = 0;

            int i;

            while (rowStart < rowCount && columnStart < columnCount)
            {
                if (count == total) break;

                for (i = rowStart; i < rowCount; i++)
                {
                    matrix[i, columnStart] = cipherTextChar[count++];
                }
                columnStart++;

                if (count == total) break;

                for (i = columnStart; i < columnCount; i++)
                {
                    matrix[rowCount - 1, i] = cipherTextChar[count++];
                }
                rowCount--;

                if (count == total) break;

                if (rowStart < rowCount)
                {
                    for (i = rowCount - 1; i >= rowStart; i--)
                    {
                        matrix[i, columnCount - 1] = cipherTextChar[count++];
                    }
                    columnCount--;
                }

                if (count == total) break;

                if (columnStart < columnCount)
                {
                    for (i = columnCount - 1; i >= columnStart; i--)
                    {
                        matrix[rowStart, i] = cipherTextChar[count++];
                    }
                    rowStart++;
                }
            }

            int columns = Math.Abs(Key);
            int rows = cipherTextChar.Length % columns != 0 ? cipherTextChar.Length / columns + 1 : cipherTextChar.Length / columns;

            int charCounter = 0;
            char[] result = new char[total];
            for (int k = 0; k < rows; k++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[charCounter++] = matrix[k, j];
                }
            }

            return new string(result);
        }
        /// <summary>
        /// Decrypts text encrypted with EncryptWithNegativeKey method
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns>Decrypted text/returns>
        private string DecryptWithNegativeKey(string cipherText)
        {
            char[] cipherTextChar = cipherText.ToCharArray();

            int columnCount = Math.Abs(Key);
            int rowCount = cipherTextChar.Length % columnCount != 0 ? cipherTextChar.Length / columnCount + 1 : cipherTextChar.Length / columnCount;

            char[,] matrix = new char[rowCount, columnCount];

            int rowStart = rowCount - 1, columnStart = columnCount - 1;
            int rowEnd = 0, columnEnd = 0;
            int total = rowCount * columnCount;
            int count = 0;

            int i;

            while (rowStart >= rowEnd && columnStart >= columnEnd)
            {
                if (count == total) break;

                for (i = rowStart; i >= rowEnd; i--)
                {
                    matrix[i, columnStart] = cipherTextChar[count++];
                }
                columnStart--;

                if (count == total) break;

                for (i = columnStart; i >= columnEnd; i--)
                {
                    matrix[rowEnd, i] = cipherTextChar[count++];
                }
                rowEnd++;

                if (count == total) break;

                if (rowStart >= rowEnd)
                {
                    for (i = rowEnd; i <= rowStart; i++)
                    {
                        matrix[i, columnEnd] = cipherTextChar[count++];
                    }
                    columnEnd++;
                }

                if (count == total) break;

                if (columnStart >= columnEnd)
                {
                    for (i = columnEnd; i <= columnStart; i++)
                    {
                        matrix[rowStart, i] = cipherTextChar[count++];
                    }
                    rowStart--;
                }
            }

            int columns = Math.Abs(Key);
            int rows = cipherTextChar.Length % columns != 0 ? cipherTextChar.Length / columns + 1 : cipherTextChar.Length / columns;

            int charCounter = 0;
            char[] result = new char[total];
            for (int k = 0; k < rows; k++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[charCounter++] = matrix[k, j];
                }
            }

            return new string(result);
        } 
        
        #endregion

        #region Public interface
        
        /// <summary>
        /// Encrypts text depending on Key property
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns>Encrypted text</returns>
        public string Encrypt(string plainText)
        {
            return Key > 0 ? EncryptWithPositiveKey(plainText) : EncryptWithNegativeKey(plainText);
        }
        /// <summary>
        /// Decrypts text depending on Key property
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns>Decrypted text</returns>
        public string Decrypt(string cipherText)
        {
            return Key > 0 ? DecryptWithPositiveKey(cipherText) : DecryptWithNegativeKey(cipherText);
        }
        public override String ToString()
        {
            return Key.ToString();
        } 
        
        #endregion

        #endregion
    }
}
