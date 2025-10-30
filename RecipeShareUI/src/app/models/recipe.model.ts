export class Recipe {
    constructor(
        public Id?: Int16Array,
        public Title?: string,
        public Ingredients?: string[],
        public Steps?: string[],
        public CookingTime?: number,
        public DietaryTag?: string
    ) {}
}
