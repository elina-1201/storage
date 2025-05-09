import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ItemPageComponent } from '../item-page/item-page.component';
import { StoragePageComponent } from '../storage-page/storage-page.component';
import { DelivererPageComponent } from '../deliverer-page/deliverer-page.component';
import { AddCategoryPage } from '../item-page/add-category-page/add-category-page.component';
import { AddCountryPage } from '../item-page/add-country-page/add-country-page.component';
import { AddItemPage } from '../item-page/add-item-page/add-item-page.component';
import { ItemPageDetails } from '../item-page/item-page-details/item-page-details.component';

const routes: Routes = [
  {path: '', 
    component: ItemPageComponent,
    children: [
      {path: '', component: ItemPageDetails},
      {path: 'add-category-page', component: AddCategoryPage},
      {path: 'add-country-page', component: AddCountryPage},
      {path: 'add-item-page', component: AddItemPage}
    ]
  },
  {path: 'storage-page', component: StoragePageComponent},
  {path: 'deliverer-page', component: DelivererPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
