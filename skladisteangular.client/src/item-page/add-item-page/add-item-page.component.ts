import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Category {
  categoryId: number,
  name: string
}
interface Country {
  countryId: number,
  name: string,
  code: string
}

interface Deliverer {
  delivererId: number,
  name: string,
  contactPhone: string,
  contactMail: string,
  address: string
}

interface Store {
  storeId: number;
  name: string;
  location: string;
}

interface Item {
  itemId: number,
  name: string,
  description: string,
  delivererId: number,
  countryId: number,
  categoryId: number,
}

interface ItemStore {
  itemId: number,
  storeId: number,
  quantity: number
}

@Component({
  selector: 'add-item-page',
  templateUrl: './add-item-page.component.html',
})
export class AddItemPage implements OnInit {

  constructor(private http: HttpClient) {}
  public categories: Category[] = [];
  public deliverers: Deliverer[] = [];
  public countries: Country[] = [];
  public stores: Store[] = [];
  public items: Item[] = [];

  public storeId: number = 0;
  public itemQuantity: number = 0;

  ngOnInit(): void {
    this.getAllCategories()
    this.getAllCountries()
    this.getAllDeliverers()
    this.getStores()
    this.getAllItems();
  }

  onItemCreate(formData: any) {

    delete formData['store'];
    delete formData["quantity"]

    this.http.post('/api/item', formData)
    .subscribe(((result) => {
      console.log(result)
    }));

    this.createItemStore();
  }

  createItemStore() {
    let itemId = this.items[0].itemId + 1;

    const itemStore: ItemStore = {
      itemId: itemId,
      storeId: Number(this.storeId),
      quantity: this.itemQuantity
    };

    this.http.post('/api/itemstore', itemStore)
    .subscribe((() => {
      alert("Item added successfully");
    }));
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
}
