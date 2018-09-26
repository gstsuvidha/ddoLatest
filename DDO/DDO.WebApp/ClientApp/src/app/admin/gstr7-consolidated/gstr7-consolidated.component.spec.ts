import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Gstr7ConsolidatedComponent } from './gstr7-consolidated.component';

describe('Gstr7ConsolidatedComponent', () => {
  let component: Gstr7ConsolidatedComponent;
  let fixture: ComponentFixture<Gstr7ConsolidatedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Gstr7ConsolidatedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Gstr7ConsolidatedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
