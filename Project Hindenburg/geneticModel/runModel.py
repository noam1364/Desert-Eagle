import tensorflow as tf
import numpy as np
import keras
import matplotlib.pyplot as plt
import sys
import globals as g

#Load model and test data
model_path = 'Model.h5'
model = keras.models.load_model(model_path)

def feedModel(input):
	output = model.predict(input)[0][0]
	print('jump probability:'+str(output))
	if output >= 0.5:
		return True
	else:
		return False
		
def main():
	input = g.getInput()	#a list of size 2,from txt file | the method is a freeze method
	while True:
		modelInput = np.array([[input[0],input[1]]])
		output = feedModel(modelInput)
		g.saveOutput(str(output))
		input = g.getInput()

if __name__== "__main__":
	main()