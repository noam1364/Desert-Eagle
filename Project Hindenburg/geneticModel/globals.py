import tensorflow as tf
import numpy as np
import keras
import os

#global functions
output_url = 'C:\Workspaces\C# workspace\Project Hindenburg\Project Hindenburg\geneticModel\output.txt'
def chooseModel():
	str = input('choose Model:')
	return 'Model'+str+'\Model'+str+'.h5'

def saveOutput(output):
	file = open(output_url,'w')
	file.write(str(output))
	file.close()
	
def getInput():	
	output = True
	while output == True or output == False:	#if the data is not and list, the game didnt pass the input yet
		file = open(output_url,'r')	#read data from file
		input = file.read()
		file.close()
		output = eval(input)
	return output