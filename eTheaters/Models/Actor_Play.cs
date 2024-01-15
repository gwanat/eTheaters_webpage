namespace eTheaters.Models
{
    public class Actor_Play
    {
        public int PlayId { get; set; }
        public Play Play { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
