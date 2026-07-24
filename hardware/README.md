# Aeon Linear Drive

Complete hardware designs for the Linear Drive used in project Aeon.

## Folder Structure

### eCAD

The Altium Project folder contains the original Altium Designer Project while the other folders contain the Documentation, Assembly and Fabrication data.
### mCAD

This folder contains the complete mechanical design in Inventor 2023 project format.

The main assembly for the complete model is **ND.NeuroLink._Main.iam**

## FAULHABER components

The linear drive is built around FAULHABER parts. Their datasheets and manuals are copyright DR. FRITZ FAULHABER GMBH & CO. KG and are not redistributed here. Download the current versions from the FAULHABER website.

### Datasheets

* Brushless DC-servomotor [Series 4490 ... B](https://www.faulhaber.com/en/products/series/4490b/)
* Planetary gearhead [Series 42GPT](https://www.faulhaber.com/en/products/series/42gpt/)

### Manuals

* Technical Manual for the MCBL/MCDC/MCLM 3002/03/06 motion controllers, document 7000.05038
* Communication and Function Manual for the MCBL/MCDC 300x RS controllers over RS232, document 7000.05029

Both manuals are in the Downloads section of the controller product page at [faulhaber.com](https://www.faulhaber.com), listed under their document numbers.

### Software

The drive is configured with [FAULHABER Motion Manager](https://www.faulhaber.com/en/support/faulhaber-motion-manager/), set up here with version 6.9.1. The configuration for this project is in the `Faulhaber Software` folder, ready to open in Motion Manager. `Linear Drive for Commutator.mpr` is the project and `Param_Linear_Drive.mcp` is the exported motor parameter set.

## Notes

The required software for the project is as follows
* eCAD - Altium Designer 23.5 or newer. Academic licenses can be obtained by contacting [Altium Education](https://www.altium.com/education/)
* mCAD - Inventor Pro 2023 or newer. Academic licenses can be obtained by contacting [Autodesk Education](https://www.autodesk.com/education/home)