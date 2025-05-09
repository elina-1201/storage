import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Store {
    storeId: number;
    name: string;
    location: string;
  }

@Component({
    selector: 'storage-page',
    templateUrl: './storage-page.component.html'
})
export class StoragePageComponent implements OnInit {
    public stores: Store[] = [];

    public addStorageClicked: Boolean = false;

    public editing: Boolean = false;
    public storeName: string = "";
    public storeLocation: string = "";
    public editingId: number = 0;

    constructor(private http: HttpClient) {}
  
    ngOnInit() {
      this.getStores();
    }
  
    getStores() {
      this.http.get<Store[]>('/api/store').subscribe(
        (result) => {
          this.stores = result;
          console.log(this.stores);
        },
        (error) => {
          console.error(error);
        }
      );
    }
  
    onStoreCreate(formData: { name: string, location: string }) {
      this.http.post('/api/store', formData)
        .subscribe((() => {
          this.getStores();
          this.addStorageClicked = false;
        }));
    }
    
    editStore(store: Store) {
      this.storeName = store.name;
      this.storeLocation = store.location;
      this.editing = true;
      this.editingId = store.storeId;
    }

    deleteStore(store: Store) {
      let result = confirm("Are you sure?");

      if(result) {
        let id: number = store.storeId; 
        this.http.delete<Store>(`/api/store/${id}`).subscribe(
          () =>  {this.getStores(); },
          (error) => console.log(error)
        );
      }
      else{
        return;
      }
    }
    
    onStoreEdit(formData: Store) {
      this.http.put<Store>(`/api/store/${this.editingId}`, formData)
      .subscribe(() => this.getStores(),
      (error) => console.log(error));
    }
}