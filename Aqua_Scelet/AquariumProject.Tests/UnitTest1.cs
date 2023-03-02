using Aqua;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AquariumProject.Tests_
{
    public class Tests
    {
        private Fish fish;
        private Aquarium aquarium;
        string shape = "Circle";
        string fishType = "shark";
        decimal fishPrice = 100;
        List<Fish> fishes = new List<Fish>();
        [SetUp]
        public void Setup()
        {
            aquarium = new Aquarium(shape);
            fish = new Fish(fishType, fishPrice);
        }

        [Test]
        public void FishConstructorShouldInicializeCorrectly()
        {
            Assert.AreEqual(fishType, fish.Type);
            Assert.AreEqual(fishPrice, fish.Price);
        }
        [Test]
        public void AquariumConstructorShouldInicializeCorrectly()
        {
            Assert.AreEqual(shape, aquarium.Shape);
            Assert.AreEqual(100, aquarium.Capacity);
            CollectionAssert.AreEqual(fishes, aquarium.Fishes);
        }
        [Test]
        public void AddMethodShoudReduceAquariumCapacity()
        {
            aquarium.AddFish(fish);
            Assert.AreEqual(99,aquarium.Capacity);
        }
        [Test]
        public void AddMethodShoudAddFish()
        {
            Aquarium newAquarium = new Aquarium(shape);
            Fish newFish = new Fish(fishType, fishPrice);

            newAquarium.AddFish(newFish);

            Assert.AreEqual(1, newAquarium.Fishes.Count);
        }
        [Test]
        public void AddMethodShoudAddExactliOneFish()
        {
            Aquarium newAquarium = new Aquarium(shape);
            Fish fish2 = new Fish(fishType, 7);
            Fish fish1 = new Fish(fishType, 6);
            aquarium.AddFish(fish1);
            aquarium.AddFish(fish2);

            Assert.AreEqual(2, aquarium.Fishes.Count);
        }
        [Test]
        public void AddMethodShoudThrowInvalidOperationException()
        {
            Aquarium newAquarium = new Aquarium(shape, 0);

            Assert.Throws<InvalidOperationException>(() => newAquarium.AddFish(fish));
        }
        [Test]
        public void AddMethodShoudThrowExactMessageException()
        {
            Aquarium newAquarium = new Aquarium(shape, 0);

            var ex = Assert.Throws<InvalidOperationException>(() => newAquarium.AddFish(fish));
            Assert.AreEqual(ex.Message, "Invalid operation");
        }
        [Test]
        public void ReportAddFishShoudPrintExactSuccessfulMessage()
        {
            aquarium.AddFish(fish);
            Assert.AreEqual("You successfully add a fish!", aquarium.ReportAddFish());
        }
        [Test]
        public void EmptyMethodShoudWorkCorrectly()
        {
            aquarium.Fishes.Add(fish);
            aquarium.Empty();
            Assert.AreEqual(0, aquarium.Fishes.Count);
        }
        [Test]
        public void EmptyMethodShoudThrowEx()
        {
            Aquarium newAquarium = new Aquarium(shape, 0);

            Assert.Throws<InvalidOperationException>(() => newAquarium.Empty());
           
        }
        [Test]
        public void EmptyMethodShoudThrowExactEx()
        {
            Aquarium newAquarium = new Aquarium(shape, 0);

            var ex = Assert.Throws<InvalidOperationException>(() => newAquarium.Empty());
            Assert.AreEqual(ex.Message, "Aquarium is empty!");
        }
    }
}