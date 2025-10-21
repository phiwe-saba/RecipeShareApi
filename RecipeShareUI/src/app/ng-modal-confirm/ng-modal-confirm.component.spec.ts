import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NgModalConfirmComponent } from './ng-modal-confirm.component';

describe('NgModalConfirmComponent', () => {
  let component: NgModalConfirmComponent;
  let fixture: ComponentFixture<NgModalConfirmComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NgModalConfirmComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NgModalConfirmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
