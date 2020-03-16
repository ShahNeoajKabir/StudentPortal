import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ParentsDashbordComponent } from './parents-dashbord.component';

describe('ParentsDashbordComponent', () => {
  let component: ParentsDashbordComponent;
  let fixture: ComponentFixture<ParentsDashbordComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ParentsDashbordComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ParentsDashbordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
