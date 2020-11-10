export class Challenge {
  constructor(
    public id: string,
    public name: string,
    public period: string,
    public activityType: string,
    public type: string, // Fondo o altitud? - missing these last 3, and the private attribute
    public distance: number,
    public sponsors: string[]
    ) {}
}
