import { Component, OnInit } from '@angular/core';

import { ReferenceData } from '../interfaces/reference-data';
import { ReferenceDataService } from '../services/reference-data.service';
import { SalesPersonResponse } from '../interfaces/sales-person-response';
import { SalesPersonService } from '../services/sales-person.service';
import { StorageService } from '../services/storage.service';

@Component({
  selector: 'app-new-customer',
  templateUrl: './new-customer.component.html',
  styleUrls: ['./new-customer.component.scss']
})
export class NewCustomerComponent implements OnInit {

  referenceData:ReferenceData = {} as ReferenceData;
  salesPersonResponse:SalesPersonResponse = {} as SalesPersonResponse;

  selectedCarType:number = 0;
  selectedLanguageOption:number = 0;

  outputMessage:string = "";

  constructor(
    private referenceDataService: ReferenceDataService,
    private salesPersonService: SalesPersonService,
    private storageService: StorageService
  ) { }

  ngOnInit(): void {
    this.getReferenceData();
  }

  getReferenceData(): void {
    this.referenceDataService.getReferenceData()
      .subscribe(referenceData => this.referenceData = referenceData);
  }

  getFreeSalesPerson(): void {
    console.debug(`selected car type: [${this.selectedCarType}]`);
    console.debug(`selected language option: [${this.selectedLanguageOption}]`);


    this.salesPersonService.assignSalesPerson(this.selectedCarType, this.selectedLanguageOption)
      .subscribe(response => {
        this.salesPersonResponse = response;
        this.processResponse();
        this.salesPersonService.salesPeopleChanged();
      });
  }

  resetStorage(): void {
    this.storageService.resetStorage()
      .subscribe( () => {
        this.selectedCarType = 0;
        this.selectedLanguageOption = 0;
        this.outputMessage = "";
        this.salesPersonService.salesPeopleChanged();
      });
  }

  private processResponse(): void {
    if (this.salesPersonResponse.salesPersonFound) {
      this.outputMessage = `The sales person assigned to you is: [${this.salesPersonResponse.salesPerson.name}]`;
    }
    else {
      this.outputMessage = "All sales people are busy. Please wait.";
    }
  }
}
