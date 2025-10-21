import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddRecipeComponent } from './Recipes/add-recipe/add-recipe.component';
import { HomeComponent } from './Recipes/home/home.component';
import { EditRecipeComponent } from './Recipes/edit-recipe/edit-recipe.component';
import { ViewRecipeComponent } from './Recipes/view-recipe/view-recipe.component';

@NgModule({
  declarations: [
    AppComponent,
    AddRecipeComponent,
    HomeComponent,
    EditRecipeComponent,
    ViewRecipeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
