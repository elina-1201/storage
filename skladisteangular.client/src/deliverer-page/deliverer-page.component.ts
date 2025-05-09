import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Deliverer {
  delivererId: number,
    name: string,
    contactPhone: string,
    contactMail: string,
    address: string
}
@Component({
    selector: 'deliverer-page',
    templateUrl: './deliverer-page.component.html'
})
export class DelivererPageComponent implements OnInit {
    public deliverers: Deliverer[] = [];
    public addDeliverereClicked: Boolean = false;

    public editing: Boolean = false;
    public name: string = "";
    public contactPhone: string = "";
    public contactEmail: string = "";
    public address: string = "";
    public editingId: number = 0;

    constructor(private http: HttpClient) {}
  
    ngOnInit() {
      this.getAllDeliverers();
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
  
    onDelivererCreate(formData: Deliverer) {
      this.http.post('/api/deliverer', formData)
        .subscribe((() => {
          this.getAllDeliverers();
        }));
    }

    editDeliverer(deliverer: Deliverer) {
      this.name = deliverer.name;
      this.contactPhone = deliverer.contactPhone;
      this.contactEmail = deliverer.contactMail;
      this.address = deliverer.address;

      this.editing = true;
      this.editingId = deliverer.delivererId;
    }

    onDelivererEdit(formData: Deliverer) {
      // console.log(formData)
      this.http.put<Deliverer>(`/api/deliverer/${this.editingId}`, formData)
      .subscribe(() => this.getAllDeliverers());
    }

    deleteDeliverer(deliverer: Deliverer) {
      let result = confirm("Are you sure?");

      if(result) {
        let id: number = deliverer.delivererId; 
        this.http.delete<Deliverer>(`/api/deliverer/${id}`).subscribe(
          () =>  {this.getAllDeliverers(); },
          (error) => console.log(error)
        );
      }
      else {
        return;
      }
    }
}