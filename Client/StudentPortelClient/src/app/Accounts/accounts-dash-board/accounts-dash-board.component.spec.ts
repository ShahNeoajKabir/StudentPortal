import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountsDashBoardComponent } from './accounts-dash-board.component';

describe('AccountsDashBoardComponent', () => {
  let component: AccountsDashBoardComponent;
  let fixture: ComponentFixture<AccountsDashBoardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountsDashBoardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountsDashBoardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
