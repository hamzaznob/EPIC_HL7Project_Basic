using NHapi.Base.Parser;
using System.Text;

namespace HL7Basic.Models
{
    public class CustomPipeParser : PipeParser
    {
        private readonly Encoding encoding;

        public CustomPipeParser(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public override string DefaultEncoding => encoding.WebName;
    }
}