
namespace BookComic.Utilities
{
    public class Functions
    {
        public static string TitleSlugGenerationAlias(string name)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(name);
        }

        internal static string? TitleSlugGenerator(string? title)
        {
            throw new NotImplementedException();
        }
    }
}
