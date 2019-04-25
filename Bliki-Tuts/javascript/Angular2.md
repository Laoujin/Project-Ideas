Angular 2
=========

FormGroup
---------
private frm: FormGroup;

constructor(private formBuilder: FormBuilder) {}

ngOnInit(): void {
	this.frm = this.formBuilder.group({
		name: 
	})
}

Routing
-------
import { Router, ActivatedRoute } from '@angular/router';
constructor(private route: ActivatedRoute) {
	const id = this.route.snapshot.params['vehicleId'];
}

Validation
----------
<form [formGroup]="myForm" novalidate (ngSubmit)="onSubmit(myForm.value)">
	<input formControlName="damageNumber" type="text" [value]="myForm.controls.damageNumber" />
	<button type="submit" [disabled]="!myForm.valid" class="btn">Save</button>
</form>

import { Validators, FormGroup, FormArray, FormBuilder, NgControlStatusGroup } from "@angular/forms";

Create the formGroup:  
this.myForm = this.formBuilder.group({
   someControlsCollection: this.formBuilder.array([])
});

this.myForm.addControl("formControlName", this.formBuilder.control(this.inspection.id));



this.myForm.controls["controlName"]



Passing data
------------
<element>
   <span header-title>{{'PanelTitle' | translate}}</span>
</element>


<ng-content select="[header-title]"></ng-content>
