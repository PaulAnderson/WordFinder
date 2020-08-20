using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    class BoardSaver
    {
        public BoardLettersModel[] boards { get; set; }
        public FileService fileService { get; set; }
        public BoardSaver(BoardLettersModel[] boards, FileService fileService = null)
        {
            this.boards = boards;
            this.fileService = fileService ?? (FileService)new FileServiceImplementation();
        }

        public void Save(string fileName)
        {
            using (Stream s = fileService.CreateFileStream(fileName))
            {
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s, boards);
            }
        }
        public void Load(string fileName)
        {
            using (Stream s = fileService.OpenFileStream(fileName))
            {
                BinaryFormatter b = new BinaryFormatter();
                var loadedBoards = (BoardLettersModel[])b.Deserialize(s);
                for (var i =0; i< loadedBoards.Length; i++)
                {
                    boards[i].Letters = loadedBoards[i].Letters;
                    boards[i].LetterMultipliers = loadedBoards[i].LetterMultipliers;
                    boards[i].MandatoryLocations = loadedBoards[i].MandatoryLocations;
                    boards[i].LastChangedTime  = loadedBoards[i].LastChangedTime;
                }
            }
        }

    }
}
