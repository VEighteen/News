using News.Model;
using Pullenti.Ner;

namespace News.Db
{
    public class PagesActions
    {
        private readonly ICollection<Page> _pages;

        public PagesActions(ICollection<Page> pages)
        {
            _pages = pages;
        }

        public ICollection<Page> FintByEntity(string name)
        {
            ICollection<Page> pages = new List<Page>();

            foreach(Page page in _pages)
            {
                var entities = page.FindEntities();
                
                foreach(var entity in entities)
                {
                    if (entity.TypeName == name) pages.Add(page);
                }
            }

            return pages;
        }

        public ICollection<Page> FindbyWord(string word)
        {
            ICollection<Page> pages = new List<Page>();

            foreach (Page page in _pages)
            {
                if(page.ContainsWord(word)) pages.Add(page);
            }

            return pages;
        }
    }
}
