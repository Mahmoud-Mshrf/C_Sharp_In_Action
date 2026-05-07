using System.Diagnostics;

namespace Attributes
{
    [DebuggerDisplay("NO: {No},, Title: {Title}")]// This attribute Determine how this class or field is shown in debugging window
    public class Update
    {
        public Update(string title, int no)
        {
            Title = title;
            No = no;
        }

        public string Title { get; set; }
        public int No { get; set; }
        public override string ToString()
        {
            return $"NO: {No}, Title: {Title} ";
        }
    }
}