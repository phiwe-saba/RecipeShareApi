import { Component, OnInit, Type } from '@angular/core';
import { Router, RouterModule  } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { HttpProviderService } from '../../Services/http-provider.service';
import { NgModalConfirm } from '../../ng-modal-confirm/ng-modal-confirm.component';
import { CommonModule } from '@angular/common';
import { Recipe } from '../../Interfaces/recipe';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterModule, ToastrModule, HttpClientModule, FormsModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit { 
  recipeList: Recipe[] = [];
  filteredRecipes: Recipe[] = [];
  dietaryTags: string[] = ['Vegan', 'Vegetarian', 'Non-Vegetarian', 'Keto', 'Gluten-Free', 'Paleo', 'Pescatarian']; 
  selectedTag: string = ''; 

  constructor(
    private router: Router,
    private modalService: NgbModal,
    private toastr: ToastrService,
    private httpProvider: HttpProviderService
  ) {}

  ngOnInit(): void {
    console.log("recipe list", this.recipeList);
    this.getAllRecipes();
  }

  getAllRecipes() {
    this.httpProvider.getAllRecipes().subscribe({
      next: (data: Recipe[]) => {
        this.recipeList = data ?? [];
        this.filteredRecipes = [...this.recipeList]; // ✅ show all on load
        console.log('API loaded recipes:', this.recipeList);

        if (this.recipeList.length === 0) {
          this.toastr.info('No recipes found.');
        }
      },
      error: (error) => {
        console.error('Error loading recipes:', error);
        this.recipeList = [];
        this.filteredRecipes = [];
        if (error?.status === 404) {
          this.toastr.info('No recipes found.');
        } else {
          this.toastr.error('Failed to load recipes.');
        }
      },
    });
  }

  /*getAllRecipes() {
    this.httpProvider.getAllRecipes().subscribe(
      (data: any) => {
        //this.recipeList = data?.body ?? [];
        this.recipeList = data ?? [];
        console.log("api response:", data);
      },
      (error: any) => {
        if (error?.status === 404) {
          this.recipeList = [];
        }
      }
    );
  }*/

  AddRecipe() {
    this.router.navigate(['AddRecipe']);
  }

  deleteRecipeConfirmation(recipe: any) {
    const modalRef = this.modalService.open(NgModalConfirm);

    console.log("delete: ",modalRef);
    modalRef.result.then(
      () => this.deleteRecipe(recipe),
      () => {}
    );
  }

  deleteRecipe(id: number) {
    this.httpProvider.deleteRecipeById(id).subscribe({
      next: () => {
      // Instantly update the list on successful delete
      this.recipeList = this.recipeList.filter(recipe => recipe.id !== id);
      this.toastr.success('Recipe deleted successfully');
      console.log(`Recipe with ID ${id} deleted`);
    },
    error: (err) => {
      this.toastr.error('Failed to delete recipe');
      console.error('Delete error:', err);
    }
    });
  }

  viewRecipe(id: number) {
    if (id) {
      console.log("view id:", id);
      this.router.navigate(['/ViewRecipe', id]);
    } else {
      this.toastr.error('Invaid recipe ID');
    }
  }

  loadAllRecipes(): void {
    this.httpProvider.getAllRecipes().subscribe({
      next: (data: Recipe[]) => {
        this.recipeList = data;
        this.filteredRecipes = data; 
      },
      error: (err) => console.error('Failed to load recipes:', err)
    });
  }

  filterByTag(): void {
    if (this.selectedTag) {
      this.httpProvider.getAllRecipesByTag(this.selectedTag).subscribe({
        next: (data: Recipe[]) => {
          if (data && data.length > 0) {
            this.filteredRecipes = data;
          } else {
            this.filteredRecipes = [];
            this.toastr.info(`No recipes found for "${this.selectedTag}"`, 'No Results');
          }
        },
        error: (err: any) => {
          /*console.error('Failed to filter recipes by tag:', err);
          this.toastr.error(`Error loading recipes for "${this.selectedTag}"`, 'Error');*/
          this.filteredRecipes = [];
        },
      });
    } else {
      this.filteredRecipes = [...this.recipeList];
    }
  }


  /*filterByTag(): void {
  if (this.selectedTag) {
    this.httpProvider.getAllRecipesByTag(this.selectedTag).subscribe({
      next: (data: Recipe[]) => {
        if (data && data.length > 0) {
          this.filteredRecipes = data;
        } else {
          this.filteredRecipes = [];
          this.toastr.info(`No recipes found for "${this.selectedTag}"`, 'No Results');
        }
      }
    });
  } else {
    // if the user clears or selects "All"
    this.filteredRecipes = [...this.recipeList];
  }
}*

  /*filterByTag(): void {
    if (this.selectedTag) {
      this.httpProvider.getAllRecipesByTag(this.selectedTag).subscribe({
        next: (data: Recipe[]) => {
          this.filteredRecipes = data;
        },
        error: (err: any) => {
          console.error('Failed to filter recipes by tag:', err);
        }
      });
    } else {
      this.filteredRecipes = [...this.recipeList];
    }
  }*/

  /*filterByTag(): void {
    if (this.selectedTag) {
      this.httpProvider.getAllRecipesByTag(this.selectedTag).subscribe({
        next: (data: Recipe[]) => {
          this.filteredRecipes = data;
        },
        error: (err: any) => console.error('Failed to filter recipes by tag:', err)
      });
    } else {
      // no tag selected → show all recipes
      this.filteredRecipes = this.recipeList;
    }
  }*/

  /*getRecipesByTag(): void {
    if (this.selectedTag === 'All' || !this.selectedTag) {
      this.getAllRecipes();
      return;
    }

    this.recipeService.getAllRecipesByTag(this.selectedTag).subscribe({
      next: (data: Recipe[]) => {
        this.recipeList = data;
        if (data.length === 0) {
          this.toastr.info(`No recipes found for tag: ${this.selectedTag}`);
        }
      },
      error: () => {
        this.toastr.error('Error filtering recipes by tag');
      }
    })
  }*/

  
}
