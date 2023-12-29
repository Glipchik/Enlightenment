namespace EnlightenmentApp.DAL.Entities
{
    public class TagEntity
    {
        public enum TagType
        {
            Tier,
            Difficulty,
            SectionsCount,
            ReturnAmount,
            Timespan,
            Custom
        }
        #nullable disable
        public int Id { get; set; }
        public TagType Type { get; set; }
        public string Value { get; set; }
        public string MetaData { get; set; }
        public bool IsBasic { get; set; }
        public ICollection<ModuleEntity> Modules { get; set; }
        public ICollection<PathEntity> Paths { get; set; }
    }
}
