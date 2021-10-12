namespace FlasherApi.Data.Dtos.Interfaces
{
    public interface IFlashCardDto
    {
        string Title { get; set; }
        string Front { get; set; }
        string Back { get; set; }        
        bool AnsweredCorrectly { get; set; }
    }
}