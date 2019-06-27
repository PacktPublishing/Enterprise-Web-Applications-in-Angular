import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddContactComponent } from './add-contact.component';

describe('AddContactComponent', () => {
  let component: AddContactComponent;
  let fixture: ComponentFixture<AddContactComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddContactComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddContactComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Should render a table with three rows', () => {
    var element = fixture.debugElement.nativeElement;    
    expect(element.querySelectorAll('table tr').length).toBe(3);
  });

  it('Should render textbox with id name', () => {
    var element = fixture.debugElement.nativeElement;    
    expect(element.querySelectorAll('table tr')[0].querySelector('input[type="text"]')).toBeTruthy();
    expect(element.querySelectorAll('table tr')[0].querySelector('input[id="name"]').id).toEqual('name');
  });

  it('Should render textbox with id email', () => {  
    var element = fixture.debugElement.nativeElement;    
    expect(element.querySelectorAll('table tr')[1].querySelector('input[type="email"]')).toBeTruthy();
    expect(element.querySelectorAll('table tr')[1].querySelector('input[type="email"]').id).toEqual('email');    
  });
  
  it('Should render button with id btnSave', () => {
    var element = fixture.debugElement.nativeElement;    
    expect(element.querySelectorAll('table tr')[2].querySelector('input[type="button"]')).toBeTruthy();
    expect(element.querySelectorAll('table tr')[2].querySelector('input[type="button"]').id).toEqual('btnSave');   
  });

  it('Clicking button calls CreateContact method', () => {
    spyOn(component, 'CreateContact').and.callFake(function(a, b){});    

    var element = fixture.debugElement.nativeElement;
    let btnSave = element.querySelectorAll('table tr')[2].querySelector('input[id="btnSave"]');
    element.querySelectorAll('table tr')[0].querySelector('input[type="text"]').value = "John";
    element.querySelectorAll('table tr')[1].querySelector('input[type="email"]').value = "John.Smith@gmail.com";      

    btnSave.click();
    expect(component.CreateContact).toHaveBeenCalledWith('John','John.Smith@gmail.com');
  });

  it('Unit Test CreateContact', function(){
    spyOn(console,'log').and.callFake(function(){});
    component.CreateContact('John','John.Smith@gmail.com');
    expect(console.log).toHaveBeenCalledWith({name: 'John', email: 'John.Smith@gmail.com'});
  });
});
