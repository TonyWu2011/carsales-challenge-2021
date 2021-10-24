import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SalesGroupComponent } from './sales-group/sales-group.component';
import { SalesPersonComponent } from './sales-person/sales-person.component';
import { NewCustomerComponent } from './new-customer/new-customer.component';

@NgModule({
  declarations: [
    AppComponent,
    SalesGroupComponent,
    SalesPersonComponent,
    NewCustomerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
