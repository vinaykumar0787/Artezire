import { Artezire.WebAppPage } from './app.po';

describe('artezire.web-app App', () => {
  let page: Artezire.WebAppPage;

  beforeEach(() => {
    page = new Artezire.WebAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
