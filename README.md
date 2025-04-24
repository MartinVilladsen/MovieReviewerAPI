RESTful API til håndtering af film og anmeldelser.

Jeg vil gerne arbejde mere med håndtering af API'er, og jeg har et mål om at få min kæreste til at se alle filmene på IMDb's Top 250-liste. På denne måde kan vi anmelde filmene ved at sende til et API, hvilket jeg tænkte kunne være et sjovt lille sideprojekt.

## Endpoints

### Movies

| Metode | Endpoint | Beskrivelse
|-----|-----|-----
| GET | /api/movies | Henter alle film
| POST | /api/movies | Tilføjer en ny film
| GET | /api/movies/id | Henter en specifik film med ID
| PUT | /api/movies/id | Opdaterer en film
| DELETE | /api/movies/id | Sletter en film


### Reviews

| Metode | Endpoint | Beskrivelse
|-----|-----|-----
| GET | /api/movies/movieId/reviews | Henter alle anmeldelser for en film
| POST | /api/movies/movieId/reviews | Tilføjer en ny anmeldelse til en film
| PUT | /api/movies/movieId/reviews/reviewId | Opdaterer en anmeldelse
| DELETE | /api/movies/movieId/reviews/reviewId | Sletter en anmeldelse


### Film
![Eksempel på json af alle film](https://github.com/user-attachments/assets/06cb993d-456c-4728-a3c7-20760c5a4b3d)


![Eksempel på json af film](https://github.com/user-attachments/assets/e1d0f78a-2970-477b-a3aa-5e15414c561b)

### Create en ny film
![Tilføjelse af ny film](https://github.com/user-attachments/assets/8ba7f724-8efc-4bde-830c-55bf79310ad2)

### Create anmeldelse af film
![LærkeReviewPost](https://github.com/user-attachments/assets/c5044269-d241-4656-9085-14b5457cb76e)
