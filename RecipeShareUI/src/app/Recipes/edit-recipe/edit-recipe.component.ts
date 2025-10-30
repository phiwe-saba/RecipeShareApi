import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpProviderService } from '../../Services/http-provider.service';
import { Recipe } from '../../Interfaces/recipe';
import { FormsModule, NgModel } from '@angular/forms';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-edit-recipe',
  standalone: true,
  imports: [FormsModule, NgIf, NgFor],
  templateUrl: './edit-recipe.component.html',
  styleUrl: './edit-recipe.component.css'
})
export class EditRecipeComponent {
  recipe: Recipe = {
    id: 0,
    title: '',
    ingredients: [],
    steps: [],
    cookingTime: 0,
    dietaryTag: ''
  };

  isLoading = true;
  recipeId!: number;
  newIngredient = '';
  newStep = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private httpProvider: HttpProviderService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.recipeId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.recipeId) {
      this.loadRecipe();
    } else {
      this.toastr.error('Invalid recipe ID');
      this.router.navigate(['/']);
    }
  }

  loadRecipe(): void {
    this.httpProvider.getRecipeById(this.recipeId).subscribe({
      next: (data: any) => {
        this.recipe = data;
        this.isLoading = false;
      },
      error: (err: any) => {
        this.toastr.error('Failed to load recipe details');
        console.error('Error loading recipe:', err);
        this.isLoading = false;
      }
    });
  }

  addIngredient(): void {
    if (this.newIngredient.trim()) {
      this.recipe.ingredients.push(this.newIngredient.trim());
      this.newIngredient = '';
    }
  }

  removeIngredient(index: number): void {
    this.recipe.ingredients.splice(index, 1);
  }

  addStep(): void {
    if (this.newStep.trim()) {
      this.recipe.steps.push(this.newStep.trim());
      this.newStep = '';
    }
  }

  removeStep(index: number): void {
    this.recipe.steps.splice(index, 1);
  }

  saveRecipe(): void {
    this.httpProvider.updateRecipe(this.recipeId, this.recipe).subscribe({
      next: () => {
        this.toastr.success('Recipe updated successfully!');
        this.router.navigate(['/']);
      },
      error: (err: any) => {
        this.toastr.error('Failed to update recipe');
        console.error('Update error:', err);
      }
    });
  }

  cancel(): void {
    this.router.navigate(['/']);
  }
}
