using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public static class Training_ExercisesRepository
    {
        public static IEnumerable<Training_Exercises> GetAllExercises()
        {
            var training_ExercisesDAO = new Training_ExercisesDAO();
            return training_ExercisesDAO.GetAll();
        }
        public static IEnumerable<Exercis> GetExcersisesByDate(string date)
        {
            var username = UserRepository.GetCurrentUser();
            var training_Exercises = new Training_ExercisesDAO();
            if (training_Exercises.GetExcersisesByDate(username, date) != null)
            {
                return training_Exercises.GetExcersisesByDate(username, date).ToList();
            }
            return null;
        }

        public static int CreateTrainingExercise(int duration, int sets, int reps, Exercis exercise, Training training)
        {
            var training_Exercises = new Training_Exercises
            {
                duration = duration,
                sets = sets,
                repetition = reps,
                exercise_id = exercise.id,
                training_id = training.id
            };

            var training_ExercisesDAO = new Training_ExercisesDAO();
            return training_ExercisesDAO.CreateTrainingExercise(training_Exercises);
        }

        public static List<Training_Exercises> BulkCreateTrainingExercises(List<Training_Exercises> trainingExercisesList)
        {
            var training_ExercisesDAO = new Training_ExercisesDAO();
            return training_ExercisesDAO.BulkAddTrainingExercise(trainingExercisesList);
        }

       
    }
}
