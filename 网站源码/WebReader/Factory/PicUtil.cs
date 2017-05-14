using System.IO;

namespace WebReader.Factory
{
    public class PicUtil : CanvertUtil
    {
        public override bool CanvertFormat(string fullfilename)
        {
            string name = Path.GetFileName(fullfilename);
            File.Move(sourcepath + "/" + name, savepath + "/" + name);
            return true;
        }
    }
}