namespace Automated.UI
{ 
    public class BasePage
    {
        protected Browser Browser { get; set; }

        public BasePage(Browser driver)
        {
            Browser = driver;
        }
        
        //where should be methods for working with page, f.e. refresh, get title ets.
    }
}
