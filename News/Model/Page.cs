using Pullenti;
using Pullenti.Ner;
using ServiceStack.DataAnnotations;

namespace News.Model
{
       public class Page
    {
        [AutoIncrement]
        public int ID { get; set; }

        public string Html { get; set; } 
        
        [Required]
        public string Url { get; set; }

        public string Text { get; set; }
        
        public DateTime Date { get; set; }

        public bool ContainsWord(string text)
        {
            return Text.ToLower().Contains(text.ToLower());
        }

        public IEnumerable<Referent> FindEntities()
        {
            Sdk.InitializeAll();

            using (Processor processor = ProcessorService.CreateProcessor())
            {
                return processor.Process(new SourceOfAnalysis(Text)).Entities;
            }

        }
    }

}
