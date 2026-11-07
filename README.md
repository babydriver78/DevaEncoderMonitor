# DevaEncoderMonitor

Live position monitor for Deva Electronics encoder interfaces.

## Target hardware
DEVA001 3-Axis PCI Incremental Encoder Interface (`001-3INC-REN-PCI`).

## Simulator-first
No PCIe card available yet, so all encoder data is simulated. A real-driver stub exists behind `IEnclib` so bring-up is a one-file swap when hardware arrives.
