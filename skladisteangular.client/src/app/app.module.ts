import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { StoragePageComponent } from '../storage-page/storage-page.component';
import { DelivererPageComponent } from '../deliverer-page/deliverer-page.component';
import { ItemPageComponent } from '../item-page/item-page.component';
import { AddCategoryPage } from '../item-page/add-category-page/add-category-page.component';
import { AddCountryPage } from '../item-page/add-country-page/add-country-page.component';
import { AddItemPage } from '../item-page/add-item-page/add-item-page.component';

@NgModule({
  declarations: [
    AppComponent, 
    StoragePageComponent, 
    DelivererPageComponent, 
    ItemPageComponent,
    AddCategoryPage,
    AddCountryPage,
    AddItemPage
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
