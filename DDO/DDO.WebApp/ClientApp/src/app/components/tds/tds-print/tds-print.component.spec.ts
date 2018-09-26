import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TdsPrintComponent } from './tds-print.component';

describe('TdsPrintComponent', () => {
  let component: TdsPrintComponent;
  let fixture: ComponentFixture<TdsPrintComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TdsPrintComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TdsPrintComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
