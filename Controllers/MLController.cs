using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ML;
using PC4_TEORIA.Models;
using PC4_TEORIA.Services;

namespace PC4_TEORIA.Controllers
{
    public class MLController : Controller
    {
        private readonly ILogger<MLController> _logger;

        private readonly PredictionEnginePool<ProductoRating, ProductoRatingPrediction> _model;

        private readonly ProductoService _productoService;


        public MLController(ILogger<MLController> logger,
        PredictionEnginePool<ProductoRating, ProductoRatingPrediction> model,
        ProductoService productoService)
        {
            _logger = logger;
            _model = model;
            _productoService = productoService;
        }

        public IActionResult PredictTrending(){
            return View("Trending");
        }

        public IActionResult Index(){
            return View();
        }




        [HttpPost]
        public IActionResult PredictTrending(int id)
        {
            List<(int productoId, float Score)> ratings = new List<(int productoId, float Score)>();
            ProductoRatingPrediction prediction = null;

            foreach (var producto in _productoService.obtenerTendenciaProductos())
            {
                // Call the Rating Prediction for each movie prediction
                prediction = _model.Predict(new ProductoRating
                {
                    productoid = producto.ProductoId,
                    userid = id,
                     // Asegúrate de que coincide con el nombre de la propiedad en ProductoRating
                });

                // Add the score for recommendation of each movie in the trending movie list
                ratings.Add((producto.ProductoId,prediction.score));
            }

            ratings = ratings.ToList();

            ViewData["ratings"] = ratings;
            ViewData["trendingproductos"] = _productoService.obtenerTendenciaProductos();
            return View("Trending");
        }

        [HttpPost]
        public IActionResult Predict(int id)
        {
            List<(int productoId, float normalizedScore)> ratings = new List<(int productoId, float normalizedScore)>();
            ProductoRatingPrediction prediction = null;

            foreach (var producto in _productoService.obtenerTodosProductos())
            {
                // Call the Rating Prediction for each movie prediction
                prediction = _model.Predict(new ProductoRating
                {
                    userid = id,
                    productoid = producto.ProductoId // Asegúrate de que coincide con el nombre de la propiedad en ProductoRating
                });

                // Normalize the prediction scores for the "ratings" b/w 0 - 100
                float normalizedscore = Sigmoid(prediction.score);

                // Add the score for recommendation of each movie in the trending movie list
                ratings.Add((producto.ProductoId, normalizedscore));
            }

            ratings = ratings.OrderByDescending(r => r.normalizedScore).ToList();

            ViewData["ratings"] = ratings;
            ViewData["productos"] = _productoService.obtenerTodosProductos();
            return View("Index");
        }


        public float Sigmoid(float x)
        {
            return (float)(100 / (1 + Math.Exp(-x)));
        }



        public IActionResult Predict()
        {
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}