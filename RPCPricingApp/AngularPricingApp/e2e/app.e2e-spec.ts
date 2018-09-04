import { AngularPricingAppPage } from './app.po';

describe('angular-pricing-app App', function() {
  let page: AngularPricingAppPage;

  beforeEach(() => {
    page = new AngularPricingAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
