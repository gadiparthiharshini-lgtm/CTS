using ObserverPatternExample;

StockMarket stockMarket = new StockMarket();

MobileApp mobile = new MobileApp();
WebApp web = new WebApp();

stockMarket.Register(mobile);
stockMarket.Register(web);

stockMarket.SetStock("TCS", 3650.50);