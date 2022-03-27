using System.ComponentModel.DataAnnotations;
using Pullenti;
using Pullenti.Ner;

namespace News.Model
{
    public class Page
    {
        [Key]
        public int ID { get; set; }

        public string Html { get; set; } 
        
        [Required]
        public string Url { get; set; }

        public string Text { get; set; }
        
        public DateTime Date { get; set; }

        public Page FindPageByWord(string text)
        {
            return Text.ToLower().Contains(text.ToLower()) ? this : null;
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
