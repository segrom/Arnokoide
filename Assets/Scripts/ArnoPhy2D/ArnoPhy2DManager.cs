using System;
using System.Collections.Generic;


namespace ArnoPhy2D
{
    public class ArnoPhy2DManager
    {
        public static ArnoPhy2DManager Instance { get; private set; }

        private List<ArnoShape2D> _allShapes;
        private List<ArnoRigidbody2D> _allRigidbodies;
        
        public ArnoPhy2DManager(){
            Instance = this;
            _allShapes = new List<ArnoShape2D>();
            _allRigidbodies = new List<ArnoRigidbody2D>();
        }

        public void AddShape(ArnoShape2D rect2D){
            _allShapes.Add(rect2D);
        }
        public void DeleteShape(ArnoShape2D rect2D){
            _allShapes.Remove(rect2D);
        }
        public ArnoShape2D[] GetAllShapes(){
            return _allShapes.ToArray();
        }
        
        public void AddRigidbody(ArnoRigidbody2D rigidBody){
            _allRigidbodies.Add(rigidBody);
        }
        public void DeleteRigidbody(ArnoRigidbody2D rigidBody){
            _allRigidbodies.Remove(rigidBody);
        }
        public ArnoRigidbody2D[] GetAllRigidbodies(){
            return _allRigidbodies.ToArray();
        }
        
        
    }
}