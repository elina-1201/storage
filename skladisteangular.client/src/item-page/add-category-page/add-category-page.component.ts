import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Category {
  categoryId: number,
  name: string
}

@Component({
  selector: 'add-category-page',
  templateUrl: './add-category-page.component.html',
})

export class AddCategoryPage implements OnInit {
  public categories: Category[] = [];

  public editing: Boolean = false;
  public editingId: number = 0;
  public categoryName: string = "";
  
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getAllCategories();
  }

  getAllCategories() {
    this.http.get<Category[]>('/api/category').subscribe(
        (result) => {
          this.categories = result;
          console.log(result)
        },
        (error) => {
          console.error(error);
        }
      );
}
  onCategoryCreate(formData: {name: string}){
    this.http.post('/api/category', formData)
    .subscribe((() => {
      this.getAllCategories();
    }));
  }

  editCategory (category: Category) {
    this.categoryName = category.name;
    this.editing = true;
    this.editingId = category.categoryId;
  }

  onCategoryEdit(formData: {name: string}) {
    this.http.put<Category>(`/api/category/${this.editingId}`, formData)
    .subscribe(() => this.getAllCategories(),
    (error) => console.log(error));
  }

  deleteCategory(category: Category) {
    let result = confirm("Are you sure?");

    if(result) {
      let id: number = category.categoryId;
      this.http.delete<Category>(`/api/category/${id}`).subscribe(
        (result) =>  {
          console.log(result)
          this.getAllCategories(); 
        },
        (error) => console.log(error)
      );
    }
    else {
      return;
    }

  }
}
