namespace StefansSuperShop.Data
{
    public class NewsletterSubscriber
    {
        public int Id { get; set; }
        public int NewsletterId { get; set; }
        public Newsletter Newsletter { get; set; }
        public int SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; }
    }
}
