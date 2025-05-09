import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Deliverer {
  delivererId: number,
  name: string,
  contactPhone: string,
  contactMail: string,
  address: string
}

interface Category {
  categoryId: number,
  name: string
}

interface Country {
  countryId: number,
  name: string,
  code: string
}

interface Item {
  itemId: number,
  name: string,
  description: string,
  delivererId: number,
  countryId: number,
  categoryId: number,
  deliverer: Deliverer,
  country: Country,
  category: Category,
}
interface Store {
  storeId: number;
  name: string;
  location: string;
}

interface ItemStore {
  id: number,
  itemId: number,
  storeId: number,
  quantity: number
}

@Component({
  selector: 'item-page-details',
  templateUrl: './item-page-details.component.html',
})
export class ItemPageDetails {
  public items: Item[] = [];
  public categories: Category[] = [];
  public deliverers: Deliverer[] = [];
  public countries: Country[] = [];
  public itemStores: ItemStore[] = [];
  public stores: Store[]=[];

  public itemClicked: Boolean = true;
  public checkSameValue: Boolean = true;

  constructor(private http: HttpClient) {}

  ngOnInit() {        
      this.getAllItems();
      this.getAllCategories();
      this.getAllCountries();
      this.getAllDeliverers();
      this.getStores();
      this.getStoreItems();
  }

  getAllCategories() {
      this.http.get<Category[]>('/api/category').subscribe(
          (result) => {
            this.categories = result;
          },
          (error) => {
            console.error(error);
          }
        );
  }

  getStoreItems() {
      this.http.get<ItemStore[]>('/api/itemstore').subscribe(
          (result) => {
            this.itemStores = result;
          },
          (error) => {
            console.error(error);
          }
        );
  }

  getAllItems() {
    this.http.get<Item[]>('/api/item').subscribe(
      (result) => {
        this.items = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getAllDeliverers() {
      this.http.get<Deliverer[]>('/api/deliverer').subscribe(
        (result) => {
          this.deliverers = result;
        },
        (error) => {
          console.error(error);
        }
      );
    }

    getAllCountries() {
      this.http.get<Country[]>('/api/country').subscribe(
          (result) => {
            this.countries = result;
          },
          (error) => {
            console.error(error);
          }
        );
    }

    getStores() {
      this.http.get<Store[]>('/api/store').subscribe(
        (result) => {
          this.stores = result;
        },
        (error) => {
          console.error(error);
        }
      );
    }
}
