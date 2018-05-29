import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavigationBarComponent } from './navigation-bar.component';

describe('NavigationBarComponent', () => {
  let component: NavigationBarComponent;
  let fixture: ComponentFixture<NavigationBarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavigationBarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavigationBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have 5 tabs', async(() => {
    const fixture = TestBed.createComponent(NavigationBarComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.querySelector('li').length == 5);
  }))

  it('should be home', async(() => {
    const fixture = TestBed.createComponent(NavigationBarComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.querySelector('li')[0].textContent == 'Home');
  }))

  it('should be weather', async(() => {
    const fixture = TestBed.createComponent(NavigationBarComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.querySelector('li')[1].textContent == 'Weather');
  }))

  it('should be news', async(() => {
    const fixture = TestBed.createComponent(NavigationBarComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.querySelector('li')[2].textContent == 'News');
  }))

  it('should be traffic', async(() => {
    const fixture = TestBed.createComponent(NavigationBarComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.querySelector('li')[3].textContent == 'Traffic');
  }))

  it('should be contact', async(() => {
    const fixture = TestBed.createComponent(NavigationBarComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.querySelector('li')[4].textContent == 'Contact');
  }))
});
