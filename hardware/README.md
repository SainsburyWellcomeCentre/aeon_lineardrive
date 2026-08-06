# Hardware

Complete hardware design for the Linear Drive used in project Aeon. This folder contains the Base Board schematic and layout, its fabrication and assembly outputs, and the FAULHABER drive configuration. The commercial components, the enclosure, the Raspberry Pi Pico, the light pipe, and the parts populated on the board, are referenced by manufacturer part number.

## Building the device

### Base Board PCB

The Base Board is our own design. To build it:

- Fabricate the bare board from the Gerber X2 and NC drill files in `eCAD/Fabrication`.
- Populate it with the parts in `eCAD/Assembly/Bill of Materials.xlsx`, using the placement in the pick and place files and the assembly drawing `eCAD/Assembly/Assembly.pdf`.
- The editable source is the Altium project in `eCAD/Altium Project`, and a schematic print is in `eCAD/Documentation`.

### Raspberry Pi Pico

The board is controlled by a Raspberry Pi Pico (RP2040), which runs the Harp firmware from the `firmware` folder. The Pico plugs into the two 20-way socket strips `J1` and `J2` through mating `Samtec TSW-120-07-L-S` headers, one per strip. You can buy the Pico from [Raspberry Pi](https://www.raspberrypi.com/products/raspberry-pi-pico/).

### Enclosure and light pipe

The Base Board mounts in a `Hammond 1457L1201EBK` extruded aluminum enclosure, an IP54 sealed case supplied with the extruded body, two die-cast end panels, a sealing gasket and `6-32` mounting screws. A flexible `Mentor 1216.1001` light pipe carries the `LED1` indicator to the panel. STEP models for these parts are available from Hammond and Mentor.

### FAULHABER drive

The linear drive is built around FAULHABER parts. Their datasheets and manuals are copyright DR. FRITZ FAULHABER GMBH & CO. KG and are not redistributed here. Download the current versions from the FAULHABER website.

Datasheets:

- Brushless DC-servomotor [Series 4490 ... B](https://www.faulhaber.com/en/products/series/4490b/)
- Planetary gearhead [Series 42GPT](https://www.faulhaber.com/en/products/series/42gpt/)

Manuals, both in the Downloads section of the controller product page at [faulhaber.com](https://www.faulhaber.com), listed under their document numbers:

- Technical Manual for the MCBL/MCDC/MCLM 3002/03/06 motion controllers, document 7000.05038
- Communication and Function Manual for the MCBL/MCDC 300x RS controllers over RS232, document 7000.05029

The drive is configured with [FAULHABER Motion Manager](https://www.faulhaber.com/en/support/faulhaber-motion-manager/), set up here with version 6.9.1. The configuration is in the `faulhaber-config` folder, ready to open in Motion Manager. `linear-drive.mpr` is the project and `linear-drive.mcp` is the exported motor parameter set.

### Mounting

The linear drive is the linear actuator in the Aeon commutation-translation system, which carries the Neuropixels commutator over the habitat. The full assembly guide, parts list, and downloadable bill of materials for that system are on the Aeon documentation site: [Commutation-Translation System](https://aeon.swc.ucl.ac.uk/user/aeon_modules/hardware/commutation_translation/).

## Referenced components

The table below lists each commercial part with its manufacturer part number. Every part populated on the board is also listed in `eCAD/Assembly/Bill of Materials.xlsx`.

| Component | Manufacturer | Part number | Role |
| --- | --- | --- | --- |
| Enclosure | Hammond | `1457L1201EBK` | Housing, includes gasket, O-ring and `6-32` screws |
| Microcontroller | Raspberry Pi | Pico (RP2040) | Runs the Harp firmware, plugs into `J1` and `J2` |
| Pico header | Samtec | `TSW-120-07-L-S` | Mates the Pico to the board |
| Light pipe | Mentor | `1216.1001` | Routes `LED1` to the panel |

## Required software

- eCAD: Altium Designer 23.5 or newer. Academic licenses can be obtained by contacting [Altium Education](https://www.altium.com/education/).

## Licensing

Each referenced component remains under its own manufacturer's terms.
