import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminUserwiseReportDashboardComponent } from './admin-userwise-report-dashboard.component';

describe('AdminUserwiseReportDashboardComponent', () => {
  let component: AdminUserwiseReportDashboardComponent;
  let fixture: ComponentFixture<AdminUserwiseReportDashboardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminUserwiseReportDashboardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminUserwiseReportDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
