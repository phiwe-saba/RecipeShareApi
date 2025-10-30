import { Component, OnInit } from '@angular/core';
import { Recipe } from '../../Interfaces/recipe';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { NgFor, NgIf } from '@angular/common';
import { RecipeService } from '../../Services/recipe.service';

@Component({
  selector: 'app-view-recipe',
  standalone: true,
  imports: [NgIf, NgFor, RouterModule],
  templateUrl: './view-recipe.component.html',
  styleUrl: './view-recipe.component.css'
})
export class ViewRecipeComponent implements OnInit{
  recipeId!: number;
  recipe?: Recipe;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private recipeService: RecipeService
  ) {}

  ngOnInit(): void {
    this.recipeId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.recipeId) {
      this.loadRecipe();
    } else {
      console.error('Invalid recipe ID');
    }
  }

  loadRecipe(): void {
    this.recipeService.getRecipeById(this.recipeId).subscribe({
      next: (data: Recipe) => {
        console.log("update: ", data);
        this.recipe = data;
      },
      error: (err: any) => {
        console.error('Failed to load recipe:', err);
      }
    });
  }

  goBack(): void {
    this.router.navigate(['/']);
  }
}
