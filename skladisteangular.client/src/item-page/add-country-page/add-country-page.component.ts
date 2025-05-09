import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Country {
  countryId: number,
  name: string,
  code: string
}

@Component({
  selector: 'add-country-page',
  templateUrl: './add-country-page.component.html',
})
export class AddCountryPage implements OnInit {
  public countries: Country[] = [];

  public editingId: number = 0;
  public countryName: string = "";
  public countryCode: string = "";

  public editing: Boolean = false;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getAllCountries();
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

  onCountryCreate(formData: {name: string, code: string}){
    this.http.post('/api/country', formData)
    .subscribe((() => {
      this.getAllCountries();
    }));
  }

  editCountry (country: Country) {
    this.countryName = country.name;
    this.countryCode = country.code;
    this.editing = true;
    this.editingId = country.countryId;
  }

    onCountryEdit(formData: {name: string, code: string}) {
      // console.log(formData, this.editingId)
    this.http.put<Country>(`/api/country/${this.editingId}`, formData)
    .subscribe(() => this.getAllCountries());
  }

  deleteCountry(country: Country) {
    let result = confirm("Are you sure?");

    if(result) {
      let id: number = country.countryId; 
  
      this.http.delete<Country>(`/api/country/${id}`).subscribe(
        () =>  {this.getAllCountries(); },
        (error) => console.log(error)
      );
    }
    else{
      return;
    }
  }
}
